import awilix, { createContainer, asClass } from "awilix"; //asValue 
const sales_Service = require("./Services/sales_Service.js");

/**
 * Calculates the sum of two numbers.
 *
 * @param {sales_Service} a - Injected Sevice into DI container.
 * @returns {service_container} service Container.
 */
const service_container = createContainer({
  injectionMode: awilix.InjectionMode.PROXY
});

service_container.register({
  sales: asClass(sales_Service).scoped(),
});

module.exports = service_container;
//using jsdoc jsdoc *.js or jsdoc file1.js file2.js file3.jsfor documentation.