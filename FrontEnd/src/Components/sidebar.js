import React from 'react';

const Sidebar = ({ products, selectedProduct, onSelectProduct }) => {
    return (
        <div style={{ border: '1px solid #ccc', padding: '10px', width: '200px', maxHeight: '300px', overflowY: 'auto' }}>
            <ul style={{ listStyle: 'none', padding: 0 }}>
                {products.map((product, index) => (
                    <li key={index}>
                        <label>
                            <input
                                type="checkbox"
                                name="products"
                                value={product}
                                checked= {selectedProduct === product}
                                onChange={() => onSelectProduct(product)}
                            />
                            {product['name']}
                        </label>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Sidebar;
