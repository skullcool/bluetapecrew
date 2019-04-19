import React, { Component } from 'react';
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import { getCategories } from '../Api'
import "react-tabs/style/react-tabs.css";
import { ProductIndex } from './ProductIndex'

export class Products extends Component {
  constructor(props) {
    super(props)
    this.state = {
      categories: []
    }
  }

  componentDidMount = async() => 
    this.setState({ categories: await getCategories()})
  

  render = () =>
  <div>
    <h1>Products</h1>
    <Tabs>
      <TabList>
        {
          this.state.categories.map((category, index) => 
            <Tab key={index}>
              {category.name}
            </Tab>)
        }
      </TabList>
      {
        this.state.categories.map((category, index) =>
          <TabPanel key={index}>
            <ProductIndex key={index} {...category} />
          </TabPanel>)
      }
    </Tabs>
  </div>
}