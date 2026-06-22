import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

function AdminMenuItems() {
  const [menuItems, setMenuItems] = useState([]);
  const navigate = useNavigate();

  const loadMenuItems = async () => {
    try {
      const token = localStorage.getItem("token");

      const response = await axios.get(
        "http://localhost:5134/api/MenuItems",
        {
          headers: {
            Authorization: `Bearer ${token}`
          }
        }
      );

      setMenuItems(response.data);
    } catch (error) {
      console.log(error);
      alert("Failed To Load Menu Items");
    }
  };

  useEffect(() => {
    loadMenuItems();
  }, []);

  const deleteMenuItem = async (id) => {
    try {
      const token = localStorage.getItem("token");

      await axios.delete(
        `http://localhost:5134/api/MenuItems/${id}`,
        {
          headers: {
            Authorization: `Bearer ${token}`
          }
        }
      );

      alert("Menu Item Deleted");

      loadMenuItems();
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div className="container">
      <h1>Admin Menu Items</h1>

      {menuItems.map((item) => (
        <div
          key={item.id}
          className="restaurant-card"
        >
          <h3>{item.itemName}</h3>

          <p>Price: ₹{item.price}</p>

          <p>
            Restaurant Id:
            {item.restaurantId}
          </p>


          <button
            className="btn"
            onClick={() =>
                navigate(`/edit-menu-item/${item.id}`)
            }
            >
            Update
            </button>

            <button
            className="btn"
            onClick={() =>
                deleteMenuItem(item.id)
            }
            >
            Delete
            </button>
        </div>
      ))}
    </div>
  );
}

export default AdminMenuItems;