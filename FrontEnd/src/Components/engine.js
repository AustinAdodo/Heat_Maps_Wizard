import React, { useState, useEffect, useRef } from "react";
import * as d3 from "d3";
import _salesService from "../Service_Container";

//npm install d3
const MyComponent = () => {
  //get dates from API and attach DateArray to class
  const dates = _salesService.resolve("sales").fetchDateData();
  const times = [
    "9:00",
    "10:00",
    "11:00",
    "12:00",
    "13:00",
    "14:00",
    "15:00",
    "16:00",
    "17:00",
    "18:00",
    "19:00",
    "20:00",
    "21:00",
    "22:00",
    "23:00",
  ];
  const [timedata] = useState(times);
  const [date] = useState([dates]);
  const svgRef = useRef();
  const w = 600;
  const h = 200;

  //fetchData
  useEffect(() => {}, []);

  //use effect should only take effect when there is a change on the Calendar date.
  useEffect(() => {
    const svg = d3
      .select(svgRef.current)
      .attr({ width: w }, { height: h })
      .style(
        { background: "#d3d3d3" },
        { "margin-top": 200 },
        { overflow: "visible" }
      );

    //scale set.
    const xScale = d3
      .scaleLinear()
      .domain([0, timedata.length - 1])
      .range([0, w]); //right to left
    const yScale = d3.scaleLinear().domain([0, h]).range([h, 0]); //top to bottom

    //generate line graph
    const result = d3
      .line()
      .x((d, i) => xScale(i))
      .y(yScale)
      .curve(d3.curveCardinal);

    //axis definitions
    const xAxisDef = d3
      .axisBottom(xScale)
      .ticks(timedata.length)
      .tickFormat((x) => x + 1);
    const yAxisDef = d3
      .axisLeft(yScale)
      .ticks(timedata.length)
      .tickFormat((x) => x + 1);

    //append
    svg.append("g").call(xAxisDef).attr("transform", `translate(0, ${h})`);
    svg.append("g").call(yAxisDef);

    //selection
    svg
      .selectAll("line")
      .data([timedata])
      .join("path")
      .attr({ d: (d) => result(d) }, { fill: "none" }, { stroke: "black" });
  }, [date, timedata]);
  return <div>{svgRef}</div>;
};

export default MyComponent;
