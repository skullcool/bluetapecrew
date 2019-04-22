import React, { Component } from 'react';
import "react-tabs/style/react-tabs.css";
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs'
import ColorPanel from './EditColors'
import StylePanel from './EditProductStyles';
import SizePanel from './EditSizes';
import ProductForm from './ProductForm'

export default class EditProductTabs extends Component {
  constructor(props) {
    super(props)
    this.state = {}
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount = async() => this.setState(this.props)
  handleSubmit = (event) => event.preventDefault()

  handleInputChange(event) {
    const target = event.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;
    this.setState({[name]: value});
  }

  render = () =>
    <Tabs className="card card-outline-secondary">
      <TabList className="card-header">
        <Tab>
          <h5 className="mb-0">Product</h5>
        </Tab>
        <Tab>
          <h5 className="mb-0">Styles</h5>
        </Tab>
        <Tab>
          <h5 className="mb-0">Colors</h5>
        </Tab>
        <Tab>
          <h5 className="mb-0">Sizes</h5>
        </Tab>
      </TabList>
      <TabPanel>
        <ProductForm {...this.props} />
      </TabPanel>          
      <TabPanel>
        <StylePanel {...this.props} />  
      </TabPanel>
      <TabPanel>
        <ColorPanel {...this.props} />
      </TabPanel>
      <TabPanel>
        <SizePanel {...this.props}  />
      </TabPanel>
    </Tabs>
}