 
import React, { useState, useEffect } from "react";
import { Table, Button } from "reactstrap";
import UserService from "../../Service/userService";

const ListUser = () => {
  const [user, setUser] = useState([]);
  useEffect(() => {
    fetchUser();
  }, []);

  const fetchUser = () => {
    UserService.getList().then(({ data }) => {
      setUser(data);
    });
  };
  

  return (
    <div>
      <Table>
        <thead>
          <tr>
            <th>STT</th>
            <th>User Name</th>
            <th>Email</th>
          </tr>
        </thead>
        <tbody>
          {user.map(function (item, i) {
            return (
              <tr>
                <th scope="row">{i+1}</th>
                <td>{item.userName}</td>
                <td>{item.email}</td>
              </tr>
            );
          })}
        </tbody>
      </Table>
    </div>
  );
};

export default ListUser;
