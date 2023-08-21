import awilix, { createContainer, asClass } from "awilix"; //asValue
const sales_Service = require("./Services/sales_Service.js");

const service_container = createContainer({
  injectionMode: awilix.InjectionMode.PROXY
});

service_container.register({
  sales: asClass(sales_Service).scoped(),
});

module.exports = service_container;
