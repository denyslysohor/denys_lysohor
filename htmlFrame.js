import React from "react";
export function HTMLFrame(props) {
  let iframe_ref = null;
  const writeHTML = (frame) => {
    if (!frame) {
      return;
    }
    iframe_ref = frame;
    let doc = frame.contentDocument;
    doc.open();
    doc.write(props.content);
    doc.close();
    frame.style.width = props.width || "100%";
    frame.style.height =
      props.height || `${frame.contentWindow.document.body.scrollHeight}px`;
  };
  return (
    <iframe
      title={props.title || ""}
      src="about:blank"
      scrolling="no"
      frameBorder="0"
      ref={writeHTML}
    />
  );
}
