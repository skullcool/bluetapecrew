import React from 'react'

const TableHead = ({columns}) =>
<thead>
  <tr>
    {columns.map(column => <th key={column}>{column}</th>)}
  </tr>  
</thead>

export default TableHead