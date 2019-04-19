import React, { Component } from 'react';
import "react-tabs/style/react-tabs.css";
import EditProductTabs from './EditProductTabs'
import * as api from '../Api'
import ProductImages from './EditProductImages'

export class Edit extends Component {
  constructor(props) {
    super(props)
    this.state = {
      product: {},
      styleVm: {}
    }
  }

  componentDidMount = async() => {
    const id = this.props.match.params.id
    const imageVm = await api.getProductImages(id)
    this.setState({
      product: await api.getProduct(id),
      styleVm: await api.getProductStyles(id),
      imageVm
    })
  }

  render = () => {
    return (
      this.state.product.id > 0
      ? <div className="container">
          <h1>{this.state.product.name}</h1>
          <div className="row">
            <div className="col-md-6">
              <EditProductTabs {...this.state} />
            </div>
            <div className="col-md-6">
              <ProductImages {...this.state} />
            </div>
          </div>
        </div>
      : null
    )
  }
}