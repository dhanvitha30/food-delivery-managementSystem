import { useNavigate } from "react-router-dom";

function Order() {
  const navigate = useNavigate();

  const cart =
    JSON.parse(localStorage.getItem("cart")) || [];

  const total = cart.reduce(
    (sum, item) => sum + item.price,
    0
  );

  const placeOrder = () => {
    alert("Order Placed Successfully");

    localStorage.removeItem("cart");

    navigate("/restaurants");
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