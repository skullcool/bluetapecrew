import React, { Component } from 'react'
import TableHead from '../tables/TableHead'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { deleteSytle } from '../Api'
import { connect } from 'react-redux'
import { fetchStyles } from '../actions/styleActions'

export class StyleTable extends Component {
  handleTrashClick(id) {
    deleteSytle(id)
  }

  componentDidMount() {
    this.props.fetchStyles(this.props.productId)
  }

  render = () =>
    <table className="table">
      <TableHead columns={["Id","Color","Size","Price",""]} />
      <tbody>
      {
        this.props.styles.items.map(style =>
          <tr key={style.id}>
            <td>{style.id}</td>
            <td>{style.color}</td>
            <td>{style.size}</td>
            <td>{style.price}</td>
            <td>
              <button type="button" 
                className="btn btn-danger btn-sm float-right"
                onClick={()=>{this.handleTrashClick(style.id)}}
              >
                <FontAwesomeIcon icon="trash" onClick={e=>e.preventDefault()} />
              </button>
            </td>
          </tr>)
      }
      </tbody>
    </table>
}

const mapStateToProps = state => ({
  styles: state.styles
})
export default connect(mapStateToProps, { fetchStyles })(StyleTable)