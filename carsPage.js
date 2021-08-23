import { useEffect, useState } from 'react';
import { loadCars, carCaptions, cars } from "../logic/cars.js";

export function CarsPage(props) {
  const [carsView, setCarsView] = useState([]);
  useEffect(() => {
    loadCars((cars) => {
      setCarsView(cars.filter((v) => {
          let relativeLocation = window.location.pathname.substring("/Cars/".length);
          return (!relativeLocation || relativeLocation.length === 0 || v.mark.toUpperCase().indexOf(relativeLocation.toUpperCase()) === 0);
        }).map((v, i) => {
          let cells = [v.mark, v.model, v.color, v.year];
          return (
            <tr key={`ctr_${i}`}>
              {cells.map((v, j) => (
                <td key={`ctd_${i}_${j}`}>{v}</td>
              ))}
            </tr>
          );
        })
      );
    });
  }, []);
  return (
    <>
      <table border="1" width="100%">
        <thead>
          <tr>
            {carCaptions().map((v, i) => (
              <th key={`cth_${i}`}>{v}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {carsView.length > 0 ? carsView : 
            <tr>
              <td colSpan={carCaptions().length}>No results</td>
            </tr>
          }
        </tbody>
      </table>
      <br />
    </>
  );
}
