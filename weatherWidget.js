import { HTMLFrame } from "./htmlFrame";

export function WeatherWidget() {
  return (
    <HTMLFrame
      height="275px"
      width="170px"
      style={{ clear: "both" }}
      title="weather"
      content={require("./weatherWidget.html")}
    />
  );
}
