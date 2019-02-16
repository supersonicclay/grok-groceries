<template>
  <div class="shopping-list">

    <h3>Items</h3>
    <div v-for="entry of list.entries" :key="entry.uuid" @click="completeEntry(entry.uuid)">
      <!-- <td><input type="checkbox" /></td> -->
      {{entry.item.name}}
    </div>

    <h3 v-if="list.completedEntries.length">Completed</h3>
    <div v-for="entry of list.completedEntries" :key="entry.uuid" @click="uncompleteEntry(entry.uuid)">
      <!-- <td><input type="checkbox" /></td> -->
      <span style="color:red">{{entry.item.name}}</span>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

type GroceryEntry = {
  uuid: string,
  item: { uuid: string, name: string }
}

type ShoppingListData = {
  entries: GroceryEntry[],
  completedEntries: GroceryEntry[]
}

@Component({
  components: {
  },
})
export default class ShoppingList extends Vue {

  loading: boolean = true;;
  list: ShoppingListData = {
    entries: [],
    completedEntries: []
  };

  async created() {
    await this.refreshList();
    this.loading = false;
  }

  addEntry({name}: {name: string}) {
    // const newItem = {
    //   uuid: 'todo',
    //   name,
    // };
    // this.items = [...this.items, newItem];
  }

  async refreshList() {
    const listResponse = await fetch('/api/v1/shopping-list');
    const list = await listResponse.json();

    this.list = list;
  }

  async completeEntry(uuid: string) {
    await fetch(`/api/v1/shopping-list/complete?uuid=${uuid}`, {
      method: 'POST'
    });

    await this.refreshList();

    // const index = this.items.findIndex(i => i.uuid === uuid);
    // if (index === -1) {
    //   throw Error(`UUID not found: ${uuid}`);
    // }
    // const item = this.items[index];

    // this.items = [
    //   ...this.items.slice(0, index),
    //   ...this.items.slice(index + 1),
    // ];

    // this.completedItems = [item, ...this.completedItems];
  }

  uncompleteEntry(uuid: string) {
    // const index = this.completedItems.findIndex(i => i.uuid === uuid);
    // if (index === -1) {
    //   throw Error(`UUID not found: ${uuid}`);
    // }
    // const item = this.completedItems[index];

    // this.items = [
    //   ...this.items,
    //   item,
    // ];

    // this.completedItems = [
    //   ...this.completedItems.slice(0, index),
    //   ...this.completedItems.slice(index + 1),
    // ];
  }
}
</script>
