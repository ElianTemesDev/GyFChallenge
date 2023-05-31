import Table from 'react-bootstrap/Table';


export type Product = {
  price: number,
  category: string
};

export function ProductTable({items, start, end}: {items: Product[], start: number, end: number}) {
    return (
      <Table striped bordered hover variant="dark">
        <thead>
          <tr>
            <th>N°</th>
            <th>Precio</th>
            <th>Categoria</th>
          </tr>
        </thead>
        <tbody>
          {items.slice(start, end).map((product, index: number) => 
          (<tr key={++index}>
            <td>{++index}</td>
            <td>{product.price}</td>
            <td>{product.category}</td>
          </tr>))}
        </tbody>
      </Table>
    );
}