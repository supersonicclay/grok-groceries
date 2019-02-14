<template>
  <div class="shopping-list">

    <h3>Items</h3>
    <div v-for="item of items" :key="item.uuid" @click="completeItem(item.uuid)">
      <!-- <td><input type="checkbox" /></td> -->
      {{item.name}}
    </div>

    <h3 v-if="completedItems.length">Completed</h3>
    <div v-for="item of completedItems" :key="item.uuid" @click="uncompleteItem(item.uuid)">
      <!-- <td><input type="checkbox" /></td> -->
      <span style="color:red">{{item.name}}</span>
    </div>

    <!-- <table>
      <thead>
        <tr>
          <th></th>
          <th>Item</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item of items" :key="item.uuid" @click="completeItem(item.uuid)">
          <td>{{item.name}}</td>
        </tr>
        <tr>
          <td>
        <tr v-for="item of completedItems" :key="item.uuid" @click="uncompleteItem(item.uuid)"
          <td>{{item.name}}</td>
        </tr> -->
        <!-- <tr>
          <td><input type="checkbox" /></td>
          <td>Milk</td>
        </tr>
        <tr>
          <td><input type="checkbox" /></td>
          <td>Eggs</td>
        </tr>
        <tr>
          <td><input type="checkbox" /></td>
          <td>Cereal</td>
        </tr> -->
      <!-- </tbody>
    </table> -->
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

type GroceryItem = { uuid: string, name: string };

const INITIAL_LIST: GroceryItem[] = [
  {
    uuid: '1',
    name: 'milk'
  },
  {
    uuid: '2',
    name: 'eggs'
  },
  {
    uuid: '3',
    name: 'cereal'
  },
  {
    uuid: '4',
    name: 'butter'
  },
];


@Component({
  components: {
  },
})
export default class ShoppingList extends Vue {
  items: GroceryItem[]  = INITIAL_LIST;
  completedItems: GroceryItem[]  = [];

  addItem({name}: {name: string}) {
    const newItem = {
      uuid: 'todo',
      name,
    };
    this.items = [...this.items, newItem];
  }

  completeItem(uuid: string) {
    const index = this.items.findIndex(i => i.uuid === uuid);
    if (index === -1) {
      throw Error(`UUID not found: ${uuid}`);
    }
    const item = this.items[index];

    this.items = [
      ...this.items.slice(0, index),
      ...this.items.slice(index + 1),
    ];

    this.completedItems = [item, ...this.completedItems];
  }

  uncompleteItem(uuid: string) {
    const index = this.completedItems.findIndex(i => i.uuid === uuid);
    if (index === -1) {
      throw Error(`UUID not found: ${uuid}`);
    }
    const item = this.completedItems[index];

    this.items = [
      ...this.items,
      item,
    ];

    this.completedItems = [
      ...this.completedItems.slice(0, index),
      ...this.completedItems.slice(index + 1),
    ];
  }
}
</script>
