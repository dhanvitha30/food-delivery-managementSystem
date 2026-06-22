import { useState } from "react";
import axios from "axios";

function AddRestaurant() {

  const [name, setName] = useState("");
  const [address, setAddress] = useState("");
  const [phone, setPhone] = useState("");

  const handleAddRestaurant = async () => {

    if (!name.trim()) {
        alert("Restaurant Name is required");
        return;
    }

    if (!address.trim()) {
        alert("Address is required");
        return;
    }

    if (!phone.trim()) {
        alert("Phone is required");
        return;
    }

    const token = localStorage.getItem("token");

    try {

        await axios.post(
        "http://localhost:5134/api/Restaurants",
        {
            name,
            address,
            phone
        },
        {
            headers: {
            Authorization: `Bearer ${token}`
            }
        }
        );

        alert("Restaurant Added Successfully");

        setName("");
        setAddress("");
        setPhone("");

    } catch (error) {

        console.log(error);
        alert("Failed To Add Restaurant");
    }
    };

  return (
    <div>
      <h1>Add Restaurant</h1>

      <input
        placeholder="Restaurant Name"
        value={name}
        required
        onChange={(e) => setName(e.target.value)}
        />

      <br /><br />

      <input
        placeholder="Address"
        value={address}
        required
        onChange={(e) => setAddress(e.target.value)}
        />

      <br /><br />

      <input
        placeholder="Phone"
        value={phone}
        required
        onChange={(e) => setPhone(e.target.value)}
        />

      <br /><br />

      <button onClick={handleAddRestaurant}>
        Add Restaurant
      </button>
    </div>
  );
}

export default AddRestaurant;