const express = require('express');
const middleware = require("./middlewares");

const indexRouter = require("./routes/index");

const app = express();
app.set('port', 8080); // Set port

// Middlewares
app.use(middleware);

// Route config
app.use('/api', indexRouter);

app.listen(app.get('port'), () => 
    console.log(`Server is running on port ${app.get('port')}`)
)
