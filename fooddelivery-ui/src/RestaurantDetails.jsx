import { useParams, useNavigate } from "react-router-dom";

function RestaurantDetails() {
  const { id } = useParams();
  const navigate = useNavigate();

  const menu = [
    {
      id: 1,
      name: "Chicken Biryani",
      price: 250
    },
    {
      id: 2,
      name: "Burger",
      price: 180
    },
    {
      id: 3,
      name: "Pizza",
      price: 300
    }
  ];

  return (
    <div className="container">
      <h1>Restaurant Details</h1>

      <h2>Restaurant ID: {id}</h2>

      <button
        className="btn"
        onClick={() => navigate("/cart")}
      >
        View Cart
      </button>

      <br />
      <br />

      <h3>Menu</h3>

      {menu.map((item) => (
        <div
          key={item.id}
          className="restaurant-card"
        >
          <h4>{item.name}</h4>
          <p>₹{item.price}</p>

          <button
            className="btn"
            onClick={() => {
              const cart =
                JSON.parse(localStorage.getItem("cart")) || [];

              cart.push(item);

              localStorage.setItem(
                "cart",
                JSON.stringify(cart)
              );

              alert("Item Added To Cart");
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