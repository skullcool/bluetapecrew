import React from 'react'
import { Route } from 'react-router'
import Layout from './components/Layout'
import { Products } from './product/Products'
import { Edit } from './product/EditProduct'
import Settings from './settings/Settings'
import Categories from './categories/Categories'
import Users from './users/Users'

const App = () => 
  <Layout>
    <Route exact path='/' component={Products} />
    <Route exact path='/categories' component={Categories} />
    <Route exact path='/settings' component={Settings} />
    <Route exact path='/users' component={Users} />
    <Route exact path='/product/edit/:id' component={Edit} />
  </Layout>

export default App