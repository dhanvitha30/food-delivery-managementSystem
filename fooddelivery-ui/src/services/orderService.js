import api from "./api";

export const getOrders = async () => {
    const response = await api.get("/Orders");
    return response.data;
};

export const cancelOrder = async (id) => {
    const response = await api.delete(`/Orders/${id}`);
    return response.data;
};