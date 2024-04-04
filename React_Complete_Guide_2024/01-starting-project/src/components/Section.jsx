export default function Section(props) {
  const { title, children, ...restProps } = props;
  return (
    <section {...restProps}>
      <h2>{title}</h2>
      {children}
    </section>
  );
}
