import React, { Component } from 'react';
import { addStyle } from '../Api'
import StyleTable from '../styles/StyleTable'

export default class EditProductStyles extends Component {
  constructor(props) {
    super(props)

    this.state = {
      color: 0,
      size: 0,
      price: ""
    }

    this.inputClass = "form-control form-control-sm"
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);    
  }

  handleInputChange(event) {
    const target = event.target;
    this.setState({
      [target.name]: target.value
    });
  }

  handleSubmit(event) {
    event.preventDefault()
    addStyle({
      productId: this.props.product.id,
      sizeId: this.state.size,
      colorId: this.state.color,
      price: this.state.price
    })
    window.location.reload()
  }

  render = () =>
    <div className="card card-outline-secondary">
      <div className="card-body">
        <StyleTable productId={this.props.product.id} />
          <form onSubmit={this.handleSubmit} className="form">
          <div className="form-inline">
            <div className="form-group">
              <select 
                name="color"
                className={this.inputClass}  
                onChange={this.handleInputChange}>
                <option value={0}>Color</option>
                {
                  this.props.styleVm.colors.map(color=>
                  <option 
                    value={color.id} 
                    key={color.id}>
                      {color.colorText}
                  </option>)
                }
              </select>
            </div>
            <div className="form-group">
              <select 
                name="size"
                className={this.inputClass} 
                onChange={this.handleInputChange}>
                <option value={0}>Size</option>
                {
                  this.props.styleVm.sizes.map(size=> 
                  <option 
                    value={size.id}
                    key={size.id}>{size.sizeText}
                  </option>)
                }
              </select>
            </div>
            <div className="form-group">
              <input 
                name="price"
                className={this.inputClass}
                placeholder="price" 
                type="USD"
                onChange={this.handleInputChange}
              />
            </div>
            <button
              disabled={
                this.state.color === 0 || this.state.size === 0 || this.state.price === ""
              }
              type="submit" 
              className="btn btn-success btn-sm float-right">Save</button>
              </div>
          </form>
        </div>
      </div>
}