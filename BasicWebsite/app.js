// Import the Express library
const express = require('express');

// Create an Express application
const app = express();

// Define a route for the home page
app.get('/', (req, res) => {
    res.send('Hello, World');
});

// Define a route for the health check endpoint
app.get('/health_check', (req, res) => {
    let randomDelay = Math.random() * 400;
    setTimeout(() => {
        res.send('Health check... Delay is ' + randomDelay.toFixed(2) + ' ms');
    }, randomDelay);
});

// Start the server and listen on a specific port
const PORT = 3000;
app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});