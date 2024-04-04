export default function Tabs(props) {
  const { children, buttons, ButtonContainer = "menu" } = props;
  return (
    <>
      <ButtonContainer>{buttons}</ButtonContainer>
      {children}
    </>
  );
}
