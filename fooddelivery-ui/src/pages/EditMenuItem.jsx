import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";

function EditMenuItem() {
  const { id } = useParams();

  const [itemName, setItemName] = useState("");
  const [price, setPrice] = useState("");

  const navigate = useNavigate();

  useEffect(() => {
    loadMenuItem();
  }, []);

  const loadMenuItem = async () => {
    try {
      const token = localStorage.getItem("token");

      const response = await axios.get(
        `http://localhost:5134/api/MenuItems/${id}`,
        {
          headers: {
            Authorization: `Bearer ${token}`
          }
        }
      );

      setItemName(response.data.itemName);
      setPrice(response.data.price);
    } catch (error) {
      console.log(error);
      alert("Failed To Load Menu Item");
    }
  };

  const updateMenuItem = async () => {
    try {
      const token = localStorage.getItem("token");

      await axios.put(
        `http://localhost:5134/api/MenuItems/${id}`,
        {
          itemName,
          price
        },
        {
          headers: {
            Authorization: `Bearer ${token}`
          }
        }
      );

      alert("Menu Item Updated Successfully");

      navigate("/admin-menuitems");
    } catch (error) {
      console.log(error);
      alert("Failed To Update Menu Item");
    }
  };

  return (
    <div className="container">
      <h1>Edit Menu Item</h1>

      <input
        type="text"
        value={itemName}
        onChange={(e) =>
          setItemName(e.target.value)
        }
        placeholder="Item Name"
      />

      <br />
      <br />

      <input
        type="number"
        value={price}
        onChange={(e) =>
          setPrice(e.target.value)
        }
        placeholder="Price"
      />

      <br />
      <br />

      <button
        className="btn"
        onClick={updateMenuItem}
      >
        Update Menu Item
      </button>
    </div>
  );
}

export default EditMenuItem;