import React, { Component } from 'react'
import TableHead from '../tables/TableHead'
import { getUsers } from '../Api'

export default class Users extends Component {
  constructor(props) {
    super(props)
    this.state = {
      users: []
    }
  }

  componentDidMount = async() => {
    const users = await getUsers()
    console.log(users)
    this.setState({users: users})
  }

  render = () => 
    <div>
      <h1>Users</h1>
      <p>
        <a className="btn btn-success">Create New User</a>
      </p>
      <table className="table table-condensed table-hover table-striped table-bordered">
        <TableHead columns={[
          "Admin",
          "Email / UserName",
          "Address",
          "Phone",
          "EmailConfirmed",
          "Phone Confirmed",
          "Two Factor Enabled",
          "Lockout End Date",
          "Lockout Enabled",
          "Access Failed Count"]} />
        <tbody>
        {
          this.state.users.map(user => 
            <tr key={user.id}>
              <td>
              {
                user.aspNetUserRoles.length > 0
                ? <span>X</span>
                : null
              }
              </td>
              <td>
                {user.userName}
              </td>
              <td>
                {`${user.address} ${user.city}, ${user.state} ${user.postalCode}`}
            </td>
            <td>
              {user.phonNumber}
            </td>
            <td>
              {user.emailConfirmed}
            </td>
            <td>
              {user.phoneNumberConfirmed}
            </td>
            <td>
              {user.twoFactorEnabled}
            </td>
            <td>
              {user.lockoutEndDateUtc}
            </td>
            <td>
              {user.LockoutEnabled}
            </td>
            <td>
              {user.accessFailedCount}
            </td>
            <td>
              <a className="btn btn-primary btn-sm" href={"/users/edit/" + user.id}>Edit</a>
              <a className="btn btn-secondary btn-sm" href={"/users/details/" + user.id}>Details</a>
              <a className="btn btn-danger btn-sm" href={"/users/details/" + user.id}>Delete</a>
            </td>
          </tr>)
        }
        </tbody>
      </table>
    </div>
 }