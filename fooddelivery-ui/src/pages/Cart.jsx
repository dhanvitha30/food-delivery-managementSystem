import { useState } from "react";
import axios from "axios";

function Cart() {
  const [cart, setCart] = useState(
    JSON.parse(localStorage.getItem("cart")) || []
  );

  const removeItem = (index) => {
    const updatedCart = [...cart];

    updatedCart.splice(index, 1);

    setCart(updatedCart);

    localStorage.setItem(
      "cart",
      JSON.stringify(updatedCart)
    );
  };

  const placeOrder = async () => {
    try {
      const token = localStorage.getItem("token");

      const orderItems = cart.map((item) => ({
        menuItemId: item.id,
        quantity: 1
      }));

      const orderDto = {
        orderItems: orderItems
      };

      await axios.post(
        "http://localhost:5134/api/Orders",
        orderDto,
        {
          headers: {
            Authorization: `Bearer ${token}`
          }
        }
      );

      alert("Order Placed Successfully");

      localStorage.removeItem("cart");

      setCart([]);
    } catch (error) {
      console.log(error);
      alert("Order Failed");
    }
  };

  const total = cart.reduce(
    (sum, item) => sum + item.price,
    0
  );

  return (
    <div className="container">
      <h1>Cart</h1>

      {cart.map((item, index) => (
        <div
          key={index}
          className="restaurant-card"
        >
          <h3>{item.itemName}</h3>

          <p>₹{item.price}</p>

          <button
            className="btn"
            onClick={() =>
              removeItem(index)
            }
          >
            Remove
          </button>
        </div>
      ))}

      <h2>Total: ₹{total}</h2>

      <button
        className="btn"
        onClick={placeOrder}
      >
        Place Order
      </button>
    </div>
  );
}

export default Cart;