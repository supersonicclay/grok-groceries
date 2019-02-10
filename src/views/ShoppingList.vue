<template>
  <div class="shopping-list">
    <table>
      <thead>
        <tr>
          <th></th>
          <th>Item</th>
        </tr>
      </thead>
      <tbody>
        <tr>
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
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

@Component({
  components: {
  },
})
export default class ShoppingList extends Vue {}
</script>
