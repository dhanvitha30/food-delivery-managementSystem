import { useNavigate } from "react-router-dom";
import axios from "axios";

function Order() {
  const navigate = useNavigate();

  const cart =
    JSON.parse(localStorage.getItem("cart")) || [];

  const total = cart.reduce(
    (sum, item) => sum + item.price,
    0
  );

  const placeOrder = async () => {
    try {
      const token = localStorage.getItem("token");
      const userId = localStorage.getItem("userId");

      console.log("UserId:", userId);
      console.log("Cart:", cart);

      for (const item of cart) {
        const orderData = {
          userId: Number(userId),
          menuItemId: item.id,
          quantity: 1
        };

        console.log("Sending:", orderData);

        await axios.post(
          "http://localhost:5134/api/Orders",
          orderData,
          {
            headers: {
              Authorization: `Bearer ${token}`
            }
          }
        );
      }

      alert("Order Placed Successfully");
      localStorage.removeItem("cart");
      navigate("/orders");
    } catch (error) {
      console.log(error);

      if (error.response) {
        console.log("Backend Error:");
        console.log(error.response.data);
      }

      alert("Failed To Place Order");
    }
  };

  return (
    <div className="container">
      <h1>Order Summary</h1>

      {cart.map((item, index) => (
        <div
          key={index}
          className="restaurant-card"
        >
          <h3>{item.name}</h3>
          <p>₹{item.price}</p>
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

export default Order;