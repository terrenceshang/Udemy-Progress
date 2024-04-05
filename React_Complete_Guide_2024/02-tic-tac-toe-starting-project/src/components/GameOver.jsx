export default function GameOver(props) {
  const { winner, onRestart } = props;
  return (
    <div id="game-over">
      <h2>
        {winner ? <p>{winner} won</p> : <p>It is a draw</p>}
        <p>
          <button onClick={onRestart}>Rematch!</button>
        </p>
      </h2>
    </div>
  );
}
