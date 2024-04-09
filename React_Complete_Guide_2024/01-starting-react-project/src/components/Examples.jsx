import TabButton from "../components/TabButton.jsx";
import { EXAMPLES } from "../data.js";
import { useState } from "react";
import Section from "../components/Section.jsx";
import Tabs from "./Tabs.jsx";

export default function Examples() {
  const [selectedButton, setSelectedButton] = useState("");
  function handleSelect(selectedButton) {
    setSelectedButton(selectedButton);
  }
  let tabContent = <p>Please select a topic</p>;
  if (selectedButton) {
    tabContent = (
      <div id="tab-content">
        <h3>{EXAMPLES[selectedButton].title}</h3>
        <p>{EXAMPLES[selectedButton].description}</p>
        <pre>
          <code>{EXAMPLES[selectedButton].code}</code>
        </pre>
      </div>
    );
  }

  const buttons = (
    <>
      <TabButton
        isSelected={selectedButton === "components"}
        onClick={() => handleSelect("components")}
      >
        Components
      </TabButton>
      <TabButton
        isSelected={selectedButton === "jsx"}
        onClick={() => handleSelect("jsx")}
      >
        JSX
      </TabButton>
      <TabButton
        isSelected={selectedButton === "props"}
        onClick={() => handleSelect("props")}
      >
        Props
      </TabButton>
      <TabButton
        isSelected={selectedButton === "state"}
        onClick={() => handleSelect("state")}
      >
        State
      </TabButton>
    </>
  );

  return (
    <main>
      <Section id="examples" title="Examples">
        <Tabs buttons={buttons}>{tabContent}</Tabs>
      </Section>
    </main>
  );
}
