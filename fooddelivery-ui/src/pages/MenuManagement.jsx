import { useEffect, useState } from "react";
import {
    getMenuItems,
    createMenuItem,
    deleteMenuItem
} from "../services/menuService";

function MenuManagement() {

    const [menuItems, setMenuItems] = useState([]);

    const [newItem, setNewItem] = useState({
        itemName: "",
        price: "",
        restaurantId: ""
    });

    useEffect(() => {
        loadMenuItems();
    }, []);

    const loadMenuItems = async () => {
        const data = await getMenuItems();
        setMenuItems(data);
    };

    const handleAdd = async () => {
        await createMenuItem(newItem);

        setNewItem({
            itemName: "",
            price: "",
            restaurantId: ""
        });

        loadMenuItems();
    };

    const handleDelete = async (id) => {
        await deleteMenuItem(id);
        loadMenuItems();
    };

    return (
        <div>
            <h1>Menu Management</h1>

            <input
                placeholder="Item Name"
                value={newItem.itemName}
                onChange={(e) =>
                    setNewItem({
                        ...newItem,
                        itemName: e.target.value
                    })
                }
            />

            <input
                placeholder="Price"
                value={newItem.price}
                onChange={(e) =>
                    setNewItem({
                        ...newItem,
                        price: e.target.value
                    })
                }
            />

            <input
                placeholder="Restaurant Id"
                value={newItem.restaurantId}
                onChange={(e) =>
                    setNewItem({
                        ...newItem,
                        restaurantId: e.target.value
                    })
                }
            />

            <button onClick={handleAdd}>
                Add Menu Item
            </button>

            <hr />

            {menuItems.map(item => (
                <div key={item.id}>
                    {item.itemName} - ₹{item.price}

                    <button
                        onClick={() =>
                            handleDelete(item.id)
                        }
                    >
                        Delete
                    </button>
                </div>
            ))}
        </div>
    );
}

export default MenuManagement;