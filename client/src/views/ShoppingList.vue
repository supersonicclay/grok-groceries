<template>
  <div class="shopping-list">
    <h3>Items</h3>
    <div v-for="entry of list.entries" :key="entry.uuid" @click="completeEntry(entry.uuid)">
      <!-- <td><input type="checkbox" /></td> -->
      {{entry.item.name}}
      <span v-if="entry.quantity > 1">({{entry.quantity}})</span>
    </div>

    <div>
      <form @submit.prevent="addEntry">
        <input type="text" v-model="newEntryText">
        <button type="submit">Add</button>
      </form>
    </div>

    <div v-if="list.completedEntries.length">
      <h3>Completed</h3>
      <div>
        <button @click="clearCompletedEntries">Clear completed</button>
      </div>
      <div
        v-for="entry of list.completedEntries"
        :key="entry.uuid"
        @click="uncompleteEntry(entry.uuid)"
      >
        <span style="color:red">
          {{entry.item.name}}
          <span v-if="entry.quantity > 1">({{entry.quantity}})</span>
        </span>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

type GroceryEntry = {
  uuid: string;
  item: { uuid: string; name: string };
};

type ShoppingListData = {
  entries: GroceryEntry[];
  completedEntries: GroceryEntry[];
};

@Component({
  components: {}
})
export default class ShoppingList extends Vue {
  loading: boolean = true;
  list: ShoppingListData = {
    entries: [],
    completedEntries: []
  };
  newEntryText: string = "";

  async created() {
    await this.refreshList();
    this.loading = false;
  }

  async addEntry() {
    const newItemResponse = await fetch("/api/v1/shopping-list", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(this.newEntryText)
    });
    const newItem = await newItemResponse.json();

    this.newEntryText = "";

    await this.refreshList();
  }

  async refreshList() {
    const listResponse = await fetch("/api/v1/shopping-list");
    const list = await listResponse.json();

    this.list = list;
  }

  async completeEntry(uuid: string) {
    await fetch(`/api/v1/shopping-list/complete?uuid=${uuid}`, {
      method: "POST"
    });

    await this.refreshList();
  }

  async uncompleteEntry(uuid: string) {
    await fetch(`/api/v1/shopping-list/uncomplete?uuid=${uuid}`, {
      method: "POST"
    });

    await this.refreshList();
  }

  async clearCompletedEntries() {
    if (!confirm("Are you sure you want to clear all completed items?")) {
      return;
    }

    await fetch(`/api/v1/shopping-list/clear-completed`, {
      method: "POST"
    });

    await this.refreshList();
  }
}
</script>
