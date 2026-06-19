import { useEffect, useState } from "react";
import {
    getOrders,
    cancelOrder
} from "../services/orderService";

function OrderManagement() {

    const [orders, setOrders] = useState([]);

    useEffect(() => {
        loadOrders();
    }, []);

    const loadOrders = async () => {
        const data = await getOrders();
        setOrders(data);
    };

    const handleCancel = async (id) => {
        await cancelOrder(id);
        loadOrders();
    };

    return (
        <div>
            <h1>Order Management</h1>

            <table border="1">
                <thead>
                    <tr>
                        <th>Order Id</th>
                        <th>User Id</th>
                        <th>Total</th>
                        <th>Action</th>
                    </tr>
                </thead>

                <tbody>
                    {orders.map(order => (
                        <tr key={order.id}>
                            <td>{order.id}</td>
                            <td>{order.userId}</td>
                            <td>{order.totalAmount}</td>

                            <td>
                                <button
                                    onClick={() =>
                                        handleCancel(order.id)
                                    }
                                >
                                    Cancel
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default OrderManagement;