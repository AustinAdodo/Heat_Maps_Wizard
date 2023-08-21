import axios from "axios";

class sales_Service {
  productsApiUrl = "http://localhost:5065/api/Sales/products";
  datesApiUrl = "http://localhost:5065/api/Sales/dates";
  defaultApiUrl =
    "http://localhost:5065/api/sales/salesondate/:date = 2022-11-21";
  constructor() {
    this.defaultUrl = this.defaultApiUrl;
    this.datesUrl = this.datesApiUrl;
    this.productsUrl = this.productsApiUrl;
  }

  async fetchDateData() {
    try {
      const [response1] = await Promise.all([
        axios
          .get(this.datesApiUrl)
          .then((response) => {
            return response.data;
          })
          .catch((error) => {
            console.error(
              `There was an error retrieving the data from ${this.datesApiUrl}`,
              error
            );
          }),
      ]);
      // Log the data from the API calls
      console.log("Data from first endpoint:", response1.data);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  }

  async fetchSalesData() {
    try {
      const [response1] = await Promise.all([
        axios
          .get(this.defaultUrl)
          .then((response) => {
            return response.data;
          })
          .catch((error) => {
            console.error(
              `There was an error retrieving the data from ${this.defaultUrl}`,
              error
            );
          }),
      ]);
      // Log the data from the API calls
      console.log("Data from first endpoint:", response1.data);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  }

  async fetchDefaultData() {
    try {
      const [response1] = await Promise.all([
        axios
          .get(this.defaultUrl)
          .then((response) => {
            return response.data;
          })
          .catch((error) => {
            console.error(
              `There was an error retrieving the data from ${this.defaultUrl}`,
              error
            );
          }),
      ]);
      // Log the data from the API calls
      console.log("Data from first endpoint:", response1.data);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  }
}

module.exports = sales_Service;
