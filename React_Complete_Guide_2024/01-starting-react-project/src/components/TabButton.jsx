export default function TabButton(props) {
  const { children, isSelected, ...restProps } = props;
  return (
    <li>
      <button className={isSelected ? "active" : undefined} {...restProps}>
        {children}
      </button>
    </li>
  );
}
