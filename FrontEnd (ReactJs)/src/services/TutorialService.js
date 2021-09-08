import http from "../http-common";

const getAll = () => {
    return http.get("/tutorial");
  };
  
  const get = id => {
    return http.get(`/tutorial/${id}`);
  };
  
  const create = data => {
    return http.post("/tutorial/add", data);
  };
  
  const update = (id, data) => {
    return http.put(`/tutorial/change`, data);
  };
  
  const remove = id => {
    return http.delete(`/tutorial/delete/${id}`);
  };
  
  const removeAll = () => {
    return http.delete(`/tutorial/deleteAll`);
  };
  
  const findByTitle = title => {
    return http.get(`/tutorial/findbytitle?title=${title}`);
  };
  
  export default {
    getAll,
    get,
    create,
    update,
    remove,
    removeAll,
    findByTitle
  };