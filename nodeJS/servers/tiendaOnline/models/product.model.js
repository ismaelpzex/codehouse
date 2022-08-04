const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const productSchema = new Schema({
    name: String,
    description: String,
    price: Number,
    department: String,
    avaliable: Boolean,
    created_at: Date
});

module.exports = mongoose.model('product', productSchema);