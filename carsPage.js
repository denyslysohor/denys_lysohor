import { carCaptions, getCars } from "./cars.js";

export function CarsPage(props) {
  return (
    <>
      <table border="1" width="100%">
        <thead>
          <tr>
            {carCaptions().map((v) => (
              <th>{v}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {getCars()
            .filter((v) => {
              let relativeLocation = window.location.pathname.substring(
                "/Cars/".length
              );
              return (
                !relativeLocation ||
                relativeLocation.length === 0 ||
                v.mark.toUpperCase().indexOf(relativeLocation.toUpperCase()) ===
                  0
              );
            })
            .map((v, i) => {
              let cells = [];
              for (let k in v) {
                cells.push(v[k]);
              }
              return (
                <tr key={`ctr_${i}`}>
                  {cells.map((v, j) => (
                    <td key={`ctd_${i}_${j}`}>{v}</td>
                  ))}
                </tr>
              );
            })}
        </tbody>
      </table>
      <br />
    </>
  );
}
