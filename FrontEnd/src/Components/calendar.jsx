import React, { useEffect } from "react";
import service_container from "../Service_Container"
import HeatMap from "heatMap"

const CalendarComponent = () => {
const dataService = service_container.resolve('sales');
const data = dataService.fetchDateData();

/**
 * Container to Inject Dependencies for services.
 * @param {sales_Service} a - Injected Sevice into DI container.
 * @returns {service_container} service Container.
 */
  useEffect(() => {
  }, []);
  const xLabels = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
  const yLabels = ["Morning", "Afternoon", "Evening"];

  return (<HeatMap xLabels={xLabels} yLabels={yLabels} data={data} />);
};


// This is a placeholder for a function that transforms the API data into the required format
// function transformData(responseData) {
//   // TODO: Implement this function based on the actual structure of your data
//   return responseData;
// }

export default CalendarComponent;
