import React, { Component } from 'react';
import TableHead from '../tables/TableHead'

export default class EditSizes extends Component {
  render = () =>
<div className="col-xs-6">
  <form action="/admin/adminproducts/createsize" method="post">
    <table className="table table-condensed table-bordered table-hover">
      <TableHead columns={["Order", "Size", ""]} />
      <tbody>
        <tr>
          <td>1</td>
          <td>XS</td>
          <td></td>
        </tr>
        <tr>
          <td><strong>Add Size:</strong></td>
          <td><input type="text" name="size" /></td>
          <td>
            <input type="hidden" name="productId" value="1" />
            <button type="submit" className="btn btn-success">Save</button>
          </td>
        </tr>
      </tbody>
    </table>
  </form>
</div>
}