import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

function Orders() {
  const navigate = useNavigate();

  const [orders, setOrders] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    loadOrders();
  }, []);

  const loadOrders = async () => {
    try {
      const token = localStorage.getItem("token");

      console.log("TOKEN:", token);

      const response = await axios.get(
        "http://localhost:5134/api/Orders",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      console.log("ORDERS RESPONSE:", response.data);

      setOrders(response.data);
    } catch (error) {
      console.log("ERROR:", error);

      if (error.response) {
        console.log(error.response.data);
      }
    } finally {
      setLoading(false);
    }
  };

  const cancelOrder = async (id) => {
    try {
      const token = localStorage.getItem("token");

      await axios.put(
        `http://localhost:5134/api/Orders/cancel/${id}`,
        {},
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      alert("Order Cancelled Successfully");

      loadOrders();
    } catch (error) {
      console.log(error);
      alert("Failed to cancel order");
    }
  };

  return (
    <div className="container">
      <h1>My Orders</h1>

      <button
        className="btn"
        onClick={() => navigate("/customer-dashboard")}
      >
        Back To Dashboard
      </button>

      <br />
      <br />

      {loading ? (
        <h3>Loading Orders...</h3>
      ) : orders.length === 0 ? (
        <h3>No Orders Found</h3>
      ) : (
        orders.map((order) => (
          <div
            key={order.id}
            className="restaurant-card"
          >
            <h3>Order #{order.id}</h3>

            <p>
              <strong>Status:</strong> {order.status}
            </p>

            <p>
              <strong>Date:</strong>{" "}
              {new Date(order.orderDate).toLocaleString()}
            </p>

            {order.status !== "Cancelled" && (
              <button
                className="btn"
                onClick={() => cancelOrder(order.id)}
              >
                Cancel Order
              </button>
            )}
          </div>
        ))
      )}
    </div>
  );
}

export default Orders;