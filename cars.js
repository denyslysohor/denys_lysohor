//cars logic

const initCar = (mark, model, color, year) => ({
  mark: mark,
  model: model,
  color: color,
  year: year
});
export const carCaptions = () => ["Mark", "Model", "Color", "Year"];
const cars = [
  initCar("Skoda", "Octavia", "Dark Gray", 2021),
  initCar("Peugeot", "9X8", "Black", 2022),
  initCar("Renault", "Duster", "Gold", 2020),
  initCar("Mercedes-Benz", "E-Class", "Black", 2015),
  initCar("Audi", "Q7", "White", 2018),
  initCar("Porsche", "Cayenne", "White", 2010),
  initCar("Fiat", "124", "Blue", 1972),
  initCar("Lada", "2101", "Green", 1972),
  initCar("Aurus", "Senat S600", "Black", 2019)
];
export const getCars = () => cars;
