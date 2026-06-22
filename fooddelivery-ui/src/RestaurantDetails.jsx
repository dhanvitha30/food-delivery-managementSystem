import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";

function RestaurantDetails() {
  const { id } = useParams();

  const [menuItems, setMenuItems] = useState([]);

  useEffect(() => {
    loadMenuItems();
  }, []);

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

      const filteredItems =
        response.data.filter(
          item => item.restaurantId === Number(id)
        );

      setMenuItems(filteredItems);

      console.log(filteredItems);
    }
    catch(error) {
      console.log(error);
    }
  };
  <div
    style={{
      display: "flex",
      justifyContent: "center",
      gap: "10px",
      marginBottom: "20px"
    }}
  >
    <button
      className="btn"
      onClick={() => navigate("/cart")}
    >
      View Cart
    </button>

    <button
      className="btn"
      onClick={() => navigate("/orders")}
    >
      Previous Orders
    </button>
  </div>

  return (
    <div className="container">
      <h1>Menu Items</h1>

      {menuItems.map((item) => (
        <div
          key={item.id}
          className="restaurant-card"
        >
          <h3>{item.itemName}</h3>

          <p>Price: ₹{item.price}</p>

          <button
            className="btn"
            onClick={() => {
              let cart =
                JSON.parse(
                  localStorage.getItem("cart")
                ) || [];

              cart.push(item);

              localStorage.setItem(
                "cart",
                JSON.stringify(cart)
              );

              alert("Added To Cart");
            }}
          >
            Add To Cart
          </button>
        </div>
      ))}
    </div>
  );
}

export default RestaurantDetails;