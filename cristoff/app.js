const express = require('express');

const indexRouter = require("./routes/index");

const app = express();
app.set('port', 8080); // Set port

// Route config
app.use(indexRouter);

app.listen(app.get('port'), () => 
    console.log(`Server is running on port ${app.get('port')}`)
)
