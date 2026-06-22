import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

function AddMenuItem() {

  const [itemName, setItemName] = useState("");
  const [price, setPrice] = useState("");
  const [restaurantId, setRestaurantId] = useState("");

  const navigate = useNavigate();

  const handleAddMenuItem = async () => {

    if (!itemName.trim()) {
      alert("Item Name is required");
      return;
    }

    if (!price || Number(price) <= 0) {
      alert("Price must be greater than 0");
      return;
    }

    if (!restaurantId || Number(restaurantId) <= 0) {
      alert("Restaurant Id is required");
      return;
    }

    const token = localStorage.getItem("token");

    try {

      const response = await axios.post(
        "http://localhost:5134/api/MenuItems",
        {
          restaurantId: Number(restaurantId),
          itemName,
          price: Number(price)
        },
        {
          headers: {
            Authorization: `Bearer ${token}`
          }
        }
      );

      alert("Menu Item Added Successfully");

      setItemName("");
      setPrice("");
      setRestaurantId("");

      navigate("/admin-menuitems");

    } catch (error) {

      console.log(error);

      if (error.response?.data) {
        alert(error.response.data);
      }
      else {
        alert("Failed To Add Menu Item");
      }
    }
  };

  return (
    <div className="container">

      <h1>Add Menu Item</h1>

      <input
        type="text"
        placeholder="Item Name"
        value={itemName}
        onChange={(e) =>
          setItemName(e.target.value)
        }
      />

      <br /><br />

      <input
        type="number"
        placeholder="Price"
        value={price}
        onChange={(e) =>
          setPrice(e.target.value)
        }
      />

      <br /><br />

      <input
        type="number"
        placeholder="Restaurant Id"
        value={restaurantId}
        onChange={(e) =>
          setRestaurantId(e.target.value)
        }
      />

      <br /><br />

      <button
        className="btn"
        onClick={handleAddMenuItem}
      >
        Add Menu Item
      </button>

    </div>
  );
}

export default AddMenuItem;