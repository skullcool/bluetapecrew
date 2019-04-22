import { connect } from 'react-redux'
import { deleteSytle } from '../Api'
import { fetchStyles } from '../actions/styleActions'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import PropTypes from 'prop-types'
import React, { Component } from 'react'
import TableHead from '../tables/TableHead'

export class StyleTable extends Component {
  handleTrashClick(id) {
    deleteSytle(id)
  }

  componentDidMount() {
    console.log(this.props)
    this.props.fetchStyles(this.props.productId)
  }

  render = () =>
    <table className="table">
      <TableHead columns={["Id","Color","Size","Price",""]} />
      <tbody>
      {
        this.props.styles.map(style =>
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

StyleTable.propTypes = {
  fetchStyles: PropTypes.func.isRequired,
  styles: PropTypes.array.isRequired
}

const mapStateToProps = state => ({
  styles: state.styles
})
export default connect(mapStateToProps, { fetchStyles })(StyleTable)