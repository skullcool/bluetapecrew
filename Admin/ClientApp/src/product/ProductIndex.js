import React from 'react'
import TableHead from '../tables/TableHead'

export const ProductIndex = ({name, products}) => 
  <div>
    <h2>{name}</h2>
    <table className="table">
      <TableHead columns={["Main Image", "Product", "Description"]} />
      <tbody>
      {
        products.map((product, index) =>
          <tr key={index}>
            <td>
              <img src={"https://localhost:5001/images/thumb/" + product.imageId} alt={product.name} />
            </td>
            <td>
              <a href={`product/edit/${product.id}`} className="bold label label-info">{product.name}</a>
            </td>
            <td>
              <p className="text text-danger">{product.description}</p>
            </td>
          </tr>)
      } 
      </tbody>
    </table>
    <hr />
  </div>