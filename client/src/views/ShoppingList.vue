<template>
  <div class="shopping-list">
    <h3>Items</h3>
    <div v-for="entry of list.entries" :key="entry.uuid" @click="completeEntry(entry.uuid)">
      <!-- <td><input type="checkbox" /></td> -->
      {{entry.item.name}}
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
        <span style="color:red">{{entry.item.name}}</span>
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

  async created() {
    await this.refreshList();
    this.loading = false;
  }

  addEntry({ name }: { name: string }) {
    // const newItem = {
    //   uuid: 'todo',
    //   name,
    // };
    // this.items = [...this.items, newItem];
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
    await fetch(`/api/v1/shopping-list/clear-completed`, {
      method: "POST"
    });

    await this.refreshList();
  }
}
</script>
