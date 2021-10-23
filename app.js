const mongoose = require('mongoose');

main().catch(err => console.log(err));

async function main(){
    await mongoose.connect('mongodb://localhost:27017/test')
}

const studentSchema = new mongoose.Schema({
    name: String,
    class_num: String,
    point: Number
})

const Student = mongoose.model('Student', studentSchema);

const test_student = new Student({name:'제현승', class_num:'20703', point:100});
console.log(silence.name);