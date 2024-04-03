export default function TabButton(props) {
  const { onSelect, children, isSelected } = props;
  return (
    <li>
      <button className={isSelected ? "active" : undefined} onClick={onSelect}>
        {children}
      </button>
    </li>
  );
}
