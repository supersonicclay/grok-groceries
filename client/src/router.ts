import Vue from 'vue';
import Router from 'vue-router';
import ShoppingList from './views/ShoppingList.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: ShoppingList,
    },
    {
      path: '/shopping-list',
      name: 'shopping-list',
      component: ShoppingList,
    },
    {
      path: '/recipes',
      name: 'recipes',
      // route level code-splitting
      // this generates a separate chunk (recipe-list.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "recipe-list" */ './views/RecipeList.vue'),
    },
  ],
});
