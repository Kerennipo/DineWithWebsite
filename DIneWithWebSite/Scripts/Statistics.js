// set the dimensions of the canvas
var margin = { top: 20, right: 20, bottom: 70, left: 40 },
    width = 600 - margin.left - margin.right,
    height = 300 - margin.top - margin.bottom;


// set the ranges
var x = d3.scale.ordinal().rangeRoundBands([0, width], .05);

var y = d3.scale.linear().range([height, 0]);

// define the axis
var xAxis = d3.svg.axis()
    .scale(x)
    .orient("bottom")


var yAxis = d3.svg.axis()
    .scale(y)
    .orient("left")
    .ticks(10);


// add the SVG element
var svg = d3.select(".g1").append("svg")
    .attr("width", width + margin.left + margin.right)
    .attr("height", height + margin.top + margin.bottom)
    .append("g")
    .attr("transform",
    "translate(" + margin.left + "," + margin.top + ")");

// load the data
d3.json(JSON.parse(CuisinesList), function (error, data) {

    data = JSON.parse(CuisinesList);
    data.forEach(function (d) {
        d.Cuisine = d.Cuisine;
        d.Count = +d.Count;
    });

    // scale the range of the data
    x.domain(data.map(function (d) { return d.Cuisine; }));
    y.domain([0, d3.max(data, function (d) { return d.Count; })]);

    // add axis
    svg.append("g")
        .attr("class", "x axis")
        .attr("transform", "translate(0," + height + ")")
        .call(xAxis)
        .selectAll("text")
        .style("text-anchor", "end")
        .attr("dx", "-.8em")
        .attr("dy", "-.55em")
        .attr("transform", "rotate(-90)");

    svg.append("g")
        .attr("class", "y axis")
        .call(yAxis)
        .append("text")
        .attr("transform", "rotate(-90)")
        .attr("y", 5)
        .attr("dy", ".71em")
        .style("text-anchor", "end")
        .text("Frequency");


    // Add bar chart
    svg.selectAll("bar")
        .data(data)
        .enter().append("rect")
        .attr("class", "bar")
        .attr("x", function (d) { return x(d.Cuisine); })
        .attr("width", x.rangeBand())
        .attr("y", function (d) { return y(d.Count); })
        .attr("height", function (d) { return height - y(d.Count); });

});


// add the SVG element
var svg2 = d3.select(".g2").append("svg")
    .attr("width", width + margin.left + margin.right)
    .attr("height", height + margin.top + margin.bottom)
    .append("g")
    .attr("transform",
    "translate(" + margin.left + "," + margin.top + ")");


// load the data
d3.json(JSON.parse(RatingList), function (error, data) {

    data = JSON.parse(RatingList);
    data.forEach(function (d) {
        d.Title = d.Title;
        d.Rating = +d.Rating;
    });

    // scale the range of the data
    x.domain(data.map(function (d) { return d.Title; }));
    y.domain([0, d3.max(data, function (d) { return d.Rating; })]);

    // add axis
    svg2.append("g")
        .attr("class", "x axis")
        .attr("transform", "translate(0," + height + ")")
        .call(xAxis)
        .selectAll("text")
        .style("text-anchor", "end")
        .attr("dx", "-.8em")
        .attr("dy", "-.55em")
        .attr("transform", "rotate(-90)");

    svg2.append("g")
        .attr("class", "y axis")
        .call(yAxis)
        .append("text")
        .attr("transform", "rotate(-90)")
        .attr("y", 5)
        .attr("dy", ".71em")
        .style("text-anchor", "end")
        .text("Count");


    // Add bar chart
    svg2.selectAll("bar")
        .data(data)
        .enter().append("rect")
        .attr("class", "bar")
        .attr("x", function (d) { return x(d.Title); })
        .attr("width", x.rangeBand())
        .attr("y", function (d) { return y(d.Rating); })
        .attr("height", function (d) { return height - y(d.Rating); });

});