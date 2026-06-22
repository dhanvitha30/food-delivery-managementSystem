import { useEffect, useState } from "react";
import { getRestaurants } from "../services/restaurantService";

function RestaurantsManagement() {
    const [restaurants, setRestaurants] = useState([]);

    useEffect(() => {
        loadRestaurants();
    }, []);

    const loadRestaurants = async () => {
        try {
            const data = await getRestaurants();
            setRestaurants(data);
        } catch (error) {
            console.log(error);
        }
    };

    return (
        <div>
            <h1>Restaurant Management</h1>

            <table border="1">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Location</th>
                    </tr>
                </thead>

                <tbody>
                    {restaurants.map((restaurant) => (
                        <tr key={restaurant.id}>
                            <td>{restaurant.id}</td>
                            <td>{restaurant.name}</td>
                            <td>{restaurant.location}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default RestaurantsManagement;