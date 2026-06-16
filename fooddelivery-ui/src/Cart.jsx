import { useNavigate } from "react-router-dom";
import { useState } from "react";

function Cart() {
  const navigate = useNavigate();

  const [cart, setCart] = useState(
    JSON.parse(localStorage.getItem("cart")) || []
  );

  const removeItem = (indexToRemove) => {
    const updatedCart = cart.filter(
      (_, index) => index !== indexToRemove
    );

    setCart(updatedCart);

    localStorage.setItem(
      "cart",
      JSON.stringify(updatedCart)
    );
  };

  const total = cart.reduce(
    (sum, item) => sum + item.price,
    0
  );

  return (
    <div className="container">
      <h1>Cart</h1>

      {cart.length === 0 ? (
        <p>Cart is Empty</p>
      ) : (
        <>
          {cart.map((item, index) => (
            <div
              key={index}
              className="restaurant-card"
            >
              <h3>{item.name}</h3>
              <p>₹{item.price}</p>

              <button
                className="btn"
                onClick={() => removeItem(index)}
              >
                Remove
              </button>
            </div>
          ))}

          <h2>Total: ₹{total}</h2>

          <button
            className="btn"
            onClick={() => navigate("/order")}
          >
            Proceed To Order
          </button>
        </>
      )}
    </div>
  );
}

export default Cart;